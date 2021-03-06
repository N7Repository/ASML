﻿using System;

namespace ASML_N7
{
    public class LauncherAdapter : IMissileLauncher
    {
        private MissileLauncher missileLauncher;

        public LauncherAdapter()
        {
            missileLauncher = new MissileLauncher();
        }

        /// <summary>
        /// Resets the missile launcher
        /// </summary>
        void IMissileLauncher.Reset()
        {
            missileLauncher.command_reset();
        }

        /// <summary>
        /// Moves the missile launcher by a relative amount.
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="phi"></param>
        void IMissileLauncher.MoveBy(double phi, double theta)
        {
            int anglePhi = Convert.ToInt32(phi);
            int angleTheta = Convert.ToInt32(theta);

            //phi is negative (left of origin)
            if (anglePhi <= 0)
            {
                anglePhi = anglePhi * -1;
                missileLauncher.command_Left(anglePhi);
            }
            //phi is positive (right of origin)
            else if (anglePhi > 0)
            {
                missileLauncher.command_Right(anglePhi);
            }
            //theta is negative (launcher aimed below origin)
            if (angleTheta <= 0)
            {
                angleTheta = angleTheta * -1;
                missileLauncher.command_Down(angleTheta);
            }
            //theta is positive (launcher aimed above origin
            else if (angleTheta > 0)
            {
                missileLauncher.command_Up(angleTheta);
            }
        }

        /// <summary>
        /// Moves the missile launcher to an absolute position.
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="theta"></param>
        void IMissileLauncher.MoveTo(double phi, double theta)
        {
            int angleTheta = Convert.ToInt32(theta);
            int anglePhi = Convert.ToInt32(phi);

            int phiToDegrees = anglePhi * 20;
            int thetaToDegrees = angleTheta * 20;


            //missileLauncher.command_reset();

            if (phiToDegrees <= 1800)
            {   
                //phiToDegrees = anglePhi * -1;
                anglePhi = (1800 - phiToDegrees);
                //was anglePhi

                missileLauncher.command_Right(anglePhi);
            }
            else if (phiToDegrees > 1800)
            {
                anglePhi = phiToDegrees - 1800;
                missileLauncher.command_Left(anglePhi);
            }
            else
            {
               // missileLauncher.command_Left(0);
            }

            if (thetaToDegrees <= 1800)
            {
                //thetaToDegrees = thetaToDegrees * -1;
                angleTheta = (1800 - thetaToDegrees);
                //was angleTheta
                //thetaToDegrees = angleTheta * -1;
                missileLauncher.command_Down(angleTheta);
            }
            else if (thetaToDegrees > 1800)
            {
                angleTheta = thetaToDegrees - 1800;
                missileLauncher.command_Up(angleTheta);
            }
            else
            {
                missileLauncher.command_Down(0);
            }
        }

        /// <summary>
        /// Fires a missile.
        /// </summary>
        void IMissileLauncher.Fire()
        {
            missileLauncher.command_Fire();
            //missileLauncher.command_reset(); //for testing only
        }

        /// <summary>
        /// Gets the phi position of the missile launcher.
        /// </summary>
        double IMissileLauncher.Phi
        {
            get { return missileLauncher.Phi; }
        }

        /// <summary>
        /// Gets the psi position of the missile launcher.
        /// </summary>
        double IMissileLauncher.Theta
        {
            get { return missileLauncher.Theta; }
        }
    }
}