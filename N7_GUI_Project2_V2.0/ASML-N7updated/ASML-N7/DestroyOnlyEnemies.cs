﻿using System.Collections.Generic;

namespace ASML_N7
{
    public class DestroyOnlyEnemies : DestroyMode
    {
        private TargetManager targetManager = TargetManager.GetInstance();
        private List<Target> uninitalizedList;
        private List<Target> killList;

        public DestroyOnlyEnemies()
        {
            uninitalizedList = targetManager.GetList();
            killList = new List<Target>();

            foreach (Target target in uninitalizedList)
            {
                if (target.isFriend != true)
                {
                    killList.Add(target);
                }
            }
        }

        public override List<Target> getTargets()
        {
            return killList;
        }
    }
}