using System;


namespace GravityBalls
{
    public class WorldModel
    {
        public double BallX;
        public double BallY;
        public double BallRadius;
        public double WorldWidth;
        public double WorldHeight;
        public double VelocityX;
        public double VelocityY;
        public double Resistance;
        public double Gravity;
        public double MouseCordX;
        public double MouseCordY;
        public double Forсe;


        public void SimulateTimeframe(double dt)
        {
            AddGravity(dt);
            AddResistance();
            AddMousePush(dt);
            Move(dt);
        }

        public double GetAngle(double x1, double y1, double x2, double y2)
        {
            return Math.Atan2((y1 - y2),(x1 - x2));
        }

        public void AddGravity(double dt)
        {
            VelocityY = VelocityY + Gravity*dt;
        }

        public void AddResistance()
        {
            VelocityX *= Resistance;
            VelocityY *= Resistance;
        }

        public void AddMousePush(double dt)
        {
            double distance = Math.Sqrt(Math.Pow(MouseCordY - BallY, 2) + Math.Pow(MouseCordX - BallX, 2));
            double angle = GetAngle(BallX, BallY, MouseCordX, MouseCordY); //Между положтельным направление Ox и вектором силы
            double pushForсe = Forсe / distance;
            VelocityX = VelocityX + Math.Cos(angle)*pushForсe*dt;
            VelocityY = VelocityY + Math.Sin(angle)*pushForсe*dt;
        }
        public void Move(double dt)
        {
            if (BallX - BallRadius <= 0 | BallX + BallRadius >= WorldWidth) VelocityX *= -1;
            if (BallY - BallRadius <= 0 | BallY + BallRadius >= WorldHeight) VelocityY *= -1;
            BallY = Math.Min(BallY + VelocityY * dt, WorldHeight - BallRadius);
            BallX = Math.Min(BallX + VelocityX * dt, WorldWidth - BallRadius);
        }
    }
}