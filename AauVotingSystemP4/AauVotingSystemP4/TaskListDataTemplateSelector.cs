using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AauVotingSystemP4
{
    public class TaskListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is VotingOption)
            {
                VotingOption taskitem = item as VotingOption;

                if (taskitem.IsNationalVotingOption)
                    return
                        element.FindResource("partyTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("candidateTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
