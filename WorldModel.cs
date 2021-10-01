using System;
using System.Data.SqlClient;

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
        public double Forse;


        public void SimulateTimeframe(double dt)
        {
            double distance = Math.Sqrt(Math.Pow(MouseCordY - BallY, 2) + Math.Pow(MouseCordX - BallX, 2));
            double angle = GetAngle(BallX, BallY, MouseCordX, MouseCordY); //Между положтельным направление Ox и вектором силы
            
            if (BallX - BallRadius <= 0 | BallX + BallRadius >= WorldWidth) VelocityX *= -1;
            if (BallY - BallRadius <= 0 | BallY + BallRadius >= WorldHeight) VelocityY *= -1;
            double PushForse = Forse / Math.Sqrt(Math.Pow(MouseCordY - BallY, 2) + Math.Pow(MouseCordX - BallX, 2));
            VelocityX = VelocityX/Resistance + Math.Cos(angle)*PushForse;
            VelocityY = VelocityY/Resistance + Gravity*dt + Math.Sin(angle)*PushForse;

            BallY = BallY + VelocityY * dt;
            BallX = BallX + VelocityX * dt;
        }

        public double GetAngle(double x1, double y1, double x2, double y2)
        {
            return Math.Atan((x1 - x2) / (y1 - y2));
        }
    }
}