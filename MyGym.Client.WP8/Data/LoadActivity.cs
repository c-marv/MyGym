using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGym.Client.WP8.Data
{
    public class LoadActivity : ObservableCollection<ActivityComplete>
    {
        ActivityComplete one = new ActivityComplete("");
        public LoadActivity()
            : base()
        {

            one.Add(new Activity("MONDAY", "Choose the activities that this day ago", ""));

            one.Add(new Activity("to paint", "", "178"));
            one.Add(new Activity("to manage", "", "150"));
            one.Add(new Activity("laboratory work", "", "130"));
            one.Add(new Activity("calculation", "", "50"));
            one.Add(new Activity("to sew", "", "114"));
            one.Add(new Activity("to iron", "", "150"));
            one.Add(new Activity("to cook", "", "130"));
            one.Add(new Activity("to play letters", "", "50"));
            one.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete two = new ActivityComplete("");

            two.Add(new Activity("TUESDAY", "Choose the activities that this day ago", ""));
            two.Add(new Activity("to paint", "", "178"));
            two.Add(new Activity("to manage", "", "150"));
            two.Add(new Activity("laboratory work", "", "130"));
            two.Add(new Activity("calculation", "", "50"));
            two.Add(new Activity("to sew", "", "114"));
            two.Add(new Activity("to iron", "", "150"));
            two.Add(new Activity("to cook", "", "130"));
            two.Add(new Activity("to play letters", "", "50"));
            two.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete three = new ActivityComplete("");

            three.Add(new Activity("WEDNESDAY", "Choose the activities that this day ago", ""));
            three.Add(new Activity("to paint", "", "178"));
            three.Add(new Activity("to manage", "", "150"));
            three.Add(new Activity("laboratory work", "", "130"));
            three.Add(new Activity("calculation", "", "50"));
            three.Add(new Activity("to sew", "", "114"));
            three.Add(new Activity("to iron", "", "150"));
            three.Add(new Activity("to cook", "", "130"));
            three.Add(new Activity("to play letters", "", "50"));
            three.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete four = new ActivityComplete("");

            four.Add(new Activity("THURSDAY", "Choose the activities that this day ago", ""));
            four.Add(new Activity("to paint", "", "178"));
            four.Add(new Activity("to manage", "", "150"));
            four.Add(new Activity("laboratory work", "", "130"));
            four.Add(new Activity("calculation", "", "50"));
            four.Add(new Activity("to sew", "", "114"));
            four.Add(new Activity("to iron", "", "150"));
            four.Add(new Activity("to cook", "", "130"));
            four.Add(new Activity("to play letters", "", "50"));
            four.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete five = new ActivityComplete("");

            five.Add(new Activity("FRIDAY", "Choose the activities that this day ago", ""));
            five.Add(new Activity("to paint", "", "178"));
            five.Add(new Activity("to manage", "", "150"));
            five.Add(new Activity("laboratory work", "", "130"));
            five.Add(new Activity("calculation", "", "50"));
            five.Add(new Activity("to sew", "", "114"));
            five.Add(new Activity("to iron", "", "150"));
            five.Add(new Activity("to cook", "", "130"));
            five.Add(new Activity("to play letters", "", "50"));
            five.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete six = new ActivityComplete("");

            six.Add(new Activity("SATURDAY", "Choose the activities that this day ago", ""));
            six.Add(new Activity("to paint", "", "178"));
            six.Add(new Activity("to manage", "", "150"));
            six.Add(new Activity("laboratory work", "", "130"));
            six.Add(new Activity("calculation", "", "50"));
            six.Add(new Activity("to sew", "", "114"));
            six.Add(new Activity("to iron", "", "150"));
            six.Add(new Activity("to cook", "", "130"));
            six.Add(new Activity("to play letters", "", "50"));
            six.Add(new Activity("to play a musical instrument", "", "114"));

            ActivityComplete seven = new ActivityComplete("");

            seven.Add(new Activity("SUNDAY", "Choose the activities that this day ago", ""));
            seven.Add(new Activity("to paint", "", "178"));
            seven.Add(new Activity("to manage", "", "150"));
            seven.Add(new Activity("laboratory work", "", "130"));
            seven.Add(new Activity("calculation", "", "50"));
            seven.Add(new Activity("to sew", "", "114"));
            seven.Add(new Activity("to iron", "", "150"));
            seven.Add(new Activity("to cook", "", "130"));
            seven.Add(new Activity("to play letters", "", "50"));
            seven.Add(new Activity("to play a musical instrument", "", "114"));

            Add(one);
            Add(two);
            Add(three);
            Add(four);
            Add(five);
            Add(six);
            Add(seven);

        }

    }
}
