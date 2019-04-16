using System;

namespace Models
{    
    public class Player {
        public Vec3 Position { get; set; }
    }

    public class Vec3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}