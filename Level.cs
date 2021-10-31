using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundTest
{
    class Level
    {
        int ActualLevel;
        public Level()
        {
            ActualLevel = 1;
        }

        public int getLevel()
        {
            return ActualLevel;
        }

        public void setLevel(int changeLevel)
        {
            ActualLevel = changeLevel;
        }
    }
}
