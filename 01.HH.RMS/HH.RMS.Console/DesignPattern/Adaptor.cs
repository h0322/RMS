using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.DesignPattern
{
    public abstract class Robot
    {
        public abstract void RobotMove();
        public abstract void RobotVoice();
        public abstract void SetAdaptor(object value);
    }
    public class AnimalAdaptor
    {
        public virtual void Move()
        { }
        public virtual void Voice() { }
    }
    public class BirdAdaptor : AnimalAdaptor
    {
        public override void Move()
        {
            base.Move();
        }
        public override void Voice()
        {
            base.Voice();
        }
    }
    public class DogAdaptor : AnimalAdaptor
    {
        public override void Move()
        {
            base.Move();
        }
        public override void Voice()
        {
            base.Voice();
        }
    }
    public class RobotAdaptor : Robot
    {
        public AnimalAdaptor animalAdaptor { get; set; }
        public override void RobotMove()
        {
            animalAdaptor.Move();
        }
        public override void RobotVoice()
        {
            animalAdaptor.Voice();
        }
        public override void SetAdaptor(object value)
        {
            animalAdaptor = (AnimalAdaptor)value;
        }
    }
    public class RobotInit
    {
        public RobotInit()
        {
            Robot robot = new RobotAdaptor();
            AnimalAdaptor animal = new DogAdaptor();
            robot.SetAdaptor(animal);
            robot.RobotMove();
            robot.RobotVoice();
        }
    }
}
