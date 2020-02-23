
#include <stdint.h> 
#include <Arduino.h>

const uint32_t startingColor = 1280;

struct sColor {
   uint8_t r;
   uint8_t g; 
   uint8_t b;
};


// If you want to command via bluetooth using esp32 uncomment the line below
// #define USE_BLUETOOTH
/*    Getting started with bluetooth on windows 10
      Name of this bluetooth device is ESP32Colors

      1. Turn on the esp32 and move it not far from the computer
      2. Click Windows button and type bluetooth and click "Bluetooth and other devices settings"
      3. Click "Add bluetooth or other devices"
      4. Click "Bluetooth"
      5. Click "ESP32Colors", wait for it to be paired and press "Done"
      6. Click "More Bluetooth options" and click tab "Com Ports"
        - Here should be a list of comports and two of them should start with the name "ESP32Colors"
        - You can use communicate via the port which has the direction "Outgoing".
*/

#ifdef ESP8266 
    // ESP8266 specific code here
    const char board[] = "ESP8266, pins D0,D1,D2";
    const int redPin         = D0;
    const int greenPin       = D1;
    const int bluePin        = D2;
    const int resolution     = 4;
    const int MaxColorValue  = 1023;
#elif defined (ESP32)
    // esp32 dev board
    const char board[] = "ESP32, pins D26,D25,D33";
    //if you want bluetooth
   #ifdef USE_BLUETOOTH
        #include "BluetoothSerial.h"
        BluetoothSerial SerialBT;
    #endif
    struct Pin {
        int number = 0;
        int channel = 0;
        
    };
    
    #define LEDC_TIMER_13_BIT  13
    #define LEDC_BASE_FREQ     8100
    const int redPin         = 26; //D26
    const int greenPin       = 25; //D25
    const int bluePin        = 33; //D33
    const int resolution     = 1;
    const uint32_t MaxColorValue  = 255;
    const int MAX_CHANNELS  = 3;
    Pin pins[MAX_CHANNELS];
    int channelCount=0;

    void ledcAnalogWrite(uint8_t channel, uint32_t value, uint32_t valueMax) {
            uint32_t duty = (LEDC_BASE_FREQ / valueMax) * ((value) < (valueMax) ? (value) : (valueMax));
           /* SerialPrint  (String("Channel: ")+String(channel));
            SerialPrint  (String(" value: ")+  String(value));
            SerialPrintln(String(" duty: ")+String(duty));*/
            ledcWrite(channel, duty);
    }

    bool analogWriteEsp32(int pinNumber, int pinValue) {
        int index=-1, i;
        for (i=0; i<MAX_CHANNELS; i++){
            if (pins[i].number == pinNumber) {
                index = i;
                break;
            }
        }
        if (index < 0){
            SerialPrintln("Pin number not found in pins");
            return false;
        }
        ledcAnalogWrite(pins[index].channel, pinValue, MaxColorValue);
    }
    

    void setupEsp32Pin(int pinNumber, int value) {
            pins[channelCount].number = pinNumber;
            pins[channelCount].channel = channelCount;
            ledcSetup(pins[channelCount].channel, LEDC_BASE_FREQ, LEDC_TIMER_13_BIT); //setup the LEDC_CHANNEL which is index
            ledcAttachPin(pinNumber, pins[channelCount].channel); //connect the pin and the LEDC_CHANNEL
            ledcAnalogWrite(pins[channelCount].channel, value, MaxColorValue);
            channelCount++;
    }

    void setupEsp32Pins() {
        setupEsp32Pin(redPin,   0);
        setupEsp32Pin(greenPin, 0);
        setupEsp32Pin(bluePin,  0);
    }
    
#else 
    // Arduino Nano PWM pins
    const char board[] = "Arduino Nano, pins D3,D5,D6";
    const int redPin         = 3;
    const int greenPin       = 5;
    const int bluePin        = 6;
    const int resolution     = 1;
    const int MaxColorValue  = 255;
#endif

sColor color;
void WriteToPins(uint16_t red, uint16_t green, uint16_t blue) {
    #ifdef ESP32
        analogWriteEsp32(redPin,  red);
        analogWriteEsp32(greenPin,green);
        analogWriteEsp32(bluePin, blue);
    #else
        analogWrite(redPin,  red);
        analogWrite(greenPin,green);
        analogWrite(bluePin, blue);
    #endif
}

void SerialPrint(String text){
     #if defined(USE_BLUETOOTH)
        SerialBT.println(text);
     #else
        Serial.println(text);
    #endif
    
}
void SerialPrintln(String text){
    text+='\n';
    SerialPrint(text);
    
}

void writeToAnalog(uint32_t uiColor) {
  color = decodeColor(uiColor);
  //color.r = color.r == 255 ? MaxColorValue : color.r *resolution;
  //color.g = color.g == 255 ? MaxColorValue : color.g *resolution;
  //color.b = color.b == 255 ? MaxColorValue : color.b *resolution;

  WriteToPins(color.r*resolution, color.g*resolution, color.b*resolution);
}

sColor decodeColor(uint32_t uiColor) {
   sColor _color;
   _color.r = (uint8_t)(uiColor >> 16);
   _color.g = (uint8_t)(uiColor >>  8);
   _color.b = (uint8_t) uiColor;
   return _color;
}

String colorToUlongString(){
  return String(encodeColor(color));
}

String colorToString(sColor color){
  String ret="red:" + String(color.r);
        ret+=" green:" + String(color.g);
        ret+=" blue:" + String(color.b);
  return ret;
}

 uint32_t encodeColor(sColor color) {
   uint32_t uiColor = (uint32_t)color.r << 16 |
                      (uint32_t)color.g <<  8 |
                      (uint32_t)color.b;
   return uiColor;
}

void setup() {
    // initialize serial:

    #ifdef ESP8266 
        pinMode     (D4, OUTPUT);
        digitalWrite(D4, HIGH  ); //TURN OFF BUILT IN LED
    #endif

    #if defined(USE_BLUETOOTH)
        SerialBT.begin("ESP32Colors");
        delay(2000);
    #else        
        Serial.begin(115200);
    #endif
    
    // make the pins outputs:
    pinMode(redPin, OUTPUT);
    pinMode(greenPin, OUTPUT);
    pinMode(bluePin, OUTPUT);
    #ifdef ESP32
        setupEsp32Pins();
    #endif
    
    SerialPrintln("----------");
    SerialPrintln("Board: " + String(board));
    SerialPrintln(String("MaxColorValue:") + String(MaxColorValue));
    SerialPrintln(  String("startingColor: ") + 
                    String(startingColor) + 
                    String( "-> ") +
                    colorToString(decodeColor(startingColor))
    );
    writeToAnalog(startingColor);
}

void loop() {
    #ifndef USE_BLUETOOTH
        while(Serial.available() > 0 ){
            String str = Serial.readString();

            if(str.substring(0) == "status\n") {  } 
            else {
                unsigned long ulColor = atol(str.c_str());
                writeToAnalog(ulColor);
            }
            Serial.println(colorToUlongString());
        }
    #else
        String str;
        if (SerialBT.available()) {
            str = SerialBT.readString();
            //SerialBT.println("You had entered: "); SerialBT.println(str);
            unsigned long ulColor = atol(str.c_str());
            writeToAnalog(ulColor);
            SerialPrintln(colorToUlongString());
        }
    #endif

}
