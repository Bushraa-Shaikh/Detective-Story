using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectiveStory
{
    internal class Detective
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }

        public Detective(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }
        public string GetGreeting()
        {
            if (Gender == "Male")
                return $"Hello Detective Mr. {Name}";
            else if (Gender == "Female")
                return $"Hello Detective Ms. {Name}";
            else
                return $"Hello Detective {Name}";
        }
    }
    internal class GameManager
    {
        public Detective CurrentDetective { get; private set; }

        public bool CreateDetective(string name, string gender)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            CurrentDetective = new Detective(name, gender);
            return true;
        }

        public string GetGreeting()
        {
            return CurrentDetective?.GetGreeting();
        }
    }
    public class Evidence
    {
        public string Name { get; set; }
        public PictureBox LivingRoomPic { get; set; }
        public PictureBox InventoryPic { get; set; }
        
        public Evidence(string name, PictureBox livingRoomPic, PictureBox inventoryPic)
        {
            Name = name;
            LivingRoomPic = livingRoomPic;
            InventoryPic = inventoryPic;

            LivingRoomPic.Visible = true;
            InventoryPic.Visible = false;

            LivingRoomPic.Click += (s, e) => CollectEvidence();
        }

        public void CollectEvidence()
        {
            LivingRoomPic.Visible = false;
            InventoryPic.Visible = true; // only show if clicked
        }
    }
    public class TimedRemover
    {
        private Control control;
        private Timer timer;
        private int duration;

        public TimedRemover(Control controlToHide, int milliseconds)
        {
            control = controlToHide;
            duration = milliseconds;
            timer = new Timer();
            timer.Interval = duration;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            control.Visible = false;
            timer.Stop();
            timer.Dispose();
        }

        public void Start()
        {
            timer.Start();
        }
    }

    public abstract class Puzzle
    {
        protected Dictionary<string, string> riddles = new Dictionary<string, string>();
        private string currentRiddle;
        private string currentAnswer;
        public int AttemptsLeft { get; private set; } = 3;

        public string GetRandomRiddle()
        {
            var rand = new Random();
            int index = rand.Next(riddles.Count);
            var pair = riddles.ElementAt(index);
            currentRiddle = pair.Key;
            currentAnswer = pair.Value;
            AttemptsLeft = 3;
            return currentRiddle;
        }

        public bool CheckAnswer(string answer)
        {
            AttemptsLeft--;
            return string.Equals(currentAnswer, answer, StringComparison.OrdinalIgnoreCase);
        }

        public bool HasAttemptsLeft()
        {
            return AttemptsLeft > 0;
        }
    }

    public class Bedroom : Puzzle
    {
        public Bedroom()
        {
            riddles.Add("What has a heart but doesn’t beat?", "Artichoke");
            riddles.Add("I’m always in bed but never sleep. What am I?", "River");
            riddles.Add("What has legs but doesn’t walk?", "Bed");
            riddles.Add("You use me to rest but I am not alive.", "Pillow");
            riddles.Add("What room do ghosts avoid?", "Living Room");
        }
    }

    public class Kitchen : Puzzle
    {
        public Kitchen()
        {
            riddles.Add("What has a handle but never opens?", "Mug");
            riddles.Add("You use me to eat soup, but I’m not a fork.", "Spoon");
            riddles.Add("I boil but I’m not angry. What am I?", "Kettle");
            riddles.Add("I’m full of holes but still hold water.", "Sponge");
            riddles.Add("I get sharper the more you use me. What am I?", "Knife");
        }
    }

    public class Library : Puzzle
    {
        public Library()
        {
            riddles.Add("What has many pages but no voice?", "Book");
            riddles.Add("I can take you places without moving.", "Book");
            riddles.Add("I have a spine but no bones.", "Book");
            riddles.Add("What building has the most stories?", "Library");
            riddles.Add("You can read me but I’m not alive.", "Book");
        }
    }

    public class Garden : Puzzle
    {
        public Garden()
        {
            riddles.Add("I’m green and grow but I’m not jealous.", "Grass");
            riddles.Add("I rise in the morning and sleep at night. What am I?", "Sun");
            riddles.Add("I’m tall and have leaves but not a book.", "Tree");
            riddles.Add("I’m planted in soil and bloom. What am I?", "Flower");
            riddles.Add("I buzz and help flowers grow. What am I?", "Bee");
        }
    }

    //public abstract class Puzzle
    //{
    //    protected Dictionary<string, string> riddles = new Dictionary<string, string>();
    //    private string currentRiddle;

    //    public string GetRandomRiddle()
    //    {
    //        var rand = new Random();
    //        int index = rand.Next(riddles.Count);
    //        currentRiddle = riddles.ElementAt(index).Key;
    //        return currentRiddle;
    //    }

    //    public bool CheckAnswer(string answer)
    //    {
    //        if (currentRiddle == null) return false;
    //        return string.Equals(riddles[currentRiddle], answer, StringComparison.OrdinalIgnoreCase);
    //    }
    //}

    //public class Bedroom : Puzzle
    //{
    //    public Bedroom()
    //    {
    //        riddles.Add("What has a heart that doesn't beat?", "Artichoke");
    //        riddles.Add("I’m always in bed but never sleep. What am I?", "River");
    //        riddles.Add("What has legs but doesn’t walk?", "Bed");
    //        riddles.Add("You use me to rest but I am not alive.", "Pillow");
    //        riddles.Add("What room do ghosts avoid?", "Living Room");
    //    }
    //}

    //public class Kitchen : Puzzle
    //{
    //    public Kitchen()
    //    {
    //        riddles.Add("What has a handle but never opens?", "Mug");
    //        riddles.Add("You use me to eat soup, but I’m not a fork.", "Spoon");
    //        riddles.Add("I boil but I’m not angry. What am I?", "Kettle");
    //        riddles.Add("I’m full of holes but still hold water.", "Sponge");
    //        riddles.Add("I get sharper the more you use me. What am I?", "Knife");
    //    }
    //}

    //public class Library : Puzzle
    //{
    //    public Library()
    //    {
    //        riddles.Add("What has many pages but no voice?", "Book");
    //        riddles.Add("You can read me but I’m not alive.", "Book");
    //        riddles.Add("I can take you places without moving.", "Book");
    //        riddles.Add("I have a spine but no bones.", "Book");
    //        riddles.Add("What building has the most stories?", "Library");
    //    }
    //}

    //public class Garden : Puzzle
    //{
    //    public Garden()
    //    {
    //        riddles.Add("I’m green and grow but I’m not jealous.", "Grass");
    //        riddles.Add("I rise in the morning and sleep at night, shining all day. What am I?", "Sun");
    //        riddles.Add("I’m tall and have leaves but I’m not a book.", "Tree");
    //        riddles.Add("I’m planted in the ground and have petals. What am I?", "Flower");
    //        riddles.Add("I buzz but I’m not a phone. I help flowers grow.", "Bee");
    //    }
    //}



}
