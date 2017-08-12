using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Data
{
    public static class Enums
    {
        public enum MoveResultStatus {
            Success  = 0,
            GameOver = 1,
            GameTie  = 3,
            InValidMove = 4,
            UserQuit = 5,
        } 
    }
}
