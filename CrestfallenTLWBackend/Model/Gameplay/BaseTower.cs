using CrestfallenTLWBackend.Controller.Gameplay;
using CrestfallenTLWBackend.Model.Core.Commands.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CrestfallenTLWBackend.Model.Gameplay
{
    public class BaseTower : ITower
    {
        public string Name { get; set; }
        public float Radius { get; set ; }
        public float AttackRatio { get; set ; }
        public float Damage { get; set; }
        private DateTime _lastFired;
        public Unit Target { get; set; }
        public Tile Tile { get; set; }
        public int TowerKey { get; set; }
        public LaneController LaneController { get; set; }

        public BaseTower(string name, float radius, float attackRatio, float damage, LaneController controller, Tile tile)
        {
            Name = name;
            Radius = radius;
            AttackRatio = attackRatio;
            Damage = damage;
            LaneController = controller;
            Tile = tile;
        }

        public void Fire()
        {
            if(_lastFired.Subtract(DateTime.Now).TotalSeconds >= AttackRatio)
                TargetEnemy();
        }

        private void TargetEnemy()
        {
            if (!DealDamageToTarget())
            {
                Target = FindTarget();
                if(Target != null)
                    DealDamageToTarget();
            }
        }

        // probably bad?
        private Unit FindTarget() => LaneController.Units.Values
            .Where(x => Vector2.Distance(Tile.Position, x.Position) <= Radius)
            .AsParallel()
            .FirstOrDefault();

        private bool DealDamageToTarget()
        {

            if (Target != null && Vector2.Distance(Tile.Position, Target.Position) <= Radius)
            {
                LaneController.Simulator.GameHandler.CommandHandler.QueueCommand(
                    CmdSpawnProjectile.Construct(
                        LaneController.Player.ID.ToString(),
                        TowerKey.ToString(),
                        Target.ToString()),
                    LaneController.Player);

                Target.TakeDamage(Damage);
                _lastFired = DateTime.Now;
                return true;
            }
            return false;
        }

        public ITower Clone() => MemberwiseClone() as ITower;
    }
}
