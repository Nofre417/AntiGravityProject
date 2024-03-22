namespace MainMenu
{
    public static class BestScoreDataController
    {
        public static int Score;
        public static int Boxes;
        
        public static void SetMaxScore(int score)
        {
            if (Score < score)
            {
                Score = score;
            }
        }
        
        public static void SetMaxBoxes(int boxes)
        {
            if (Boxes < boxes)
            {
                Boxes  = boxes;
            }
        }

        public static void ResetValues()
        {
            Score = 0;
            Boxes = 0;
        }
    }
}