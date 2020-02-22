using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialColors.Data
{
     class StepRepository
    {
        private Properties.Settings settings;
        public StepRepository(Properties.Settings settings) => this.settings = settings;

        public List<Step> GetAllSteps()
        {
            var steps = settings.Steps;
            var list = new List<Step>();

            foreach (string item in steps)
            {
                list.Add(new Step(item));
            }
            return list;
        }

        internal void Save(List<Step> steps)
        {
            settings.Steps.Clear();
            var ordered = steps.OrderBy(o => o.From).ToList();
            
            //fix all Steps.From values
            for(var i = 0; i<ordered.Count(); i++)
            {
                if (i>0) { 
                    ordered[i - 1].To = ordered[i].From - 1;
                    if (i == ordered.Count() - 1)
                        ordered[i].To = 100;
                } else
                {
                    ordered[i].From = 0;
                }

            }
            
            foreach (Step item in ordered)
            {
                settings.Steps.Add(item.ToString());
            }
            settings.Save();
        }
    }
}
