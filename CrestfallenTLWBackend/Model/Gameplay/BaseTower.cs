using CrestfallenCore.Communication.Commands;
using CrestfallenTLWBackend.Controller.Gameplay;
using CrestfallenTLWBackend.Model.Interfaces;
using System;
using System.Linq;
using System.Numerics;

namespace CrestfallenTLWBackend.Model.Gameplay;

public class BaseTower : ITower
{
    public string Name { get; set; }
    public float Radius { get; set ; }
    public float AttackRatio { get; set ; }
    public float Damage { get; set; }
    public int TowerKey { get; set; }

    private DateTime _lastFired;
    public Unit Target { get; set; }
    public Tile Tile { get; set; }
    public LaneController LaneController { get; set; }

    public BaseTower(string name, float radius, float attackRatio, float damage, LaneController controller, Tile tile)
    {
        Name = name;
        Radius = radius;
        AttackRatio = attackRatio;
        Damage = damage;
        LaneController = controller;
        Tile = tile;
        _lastFired = DateTime.Now;
    }

    public void Fire()
    {
        var timeSinceLastBullet = DateTime.Now.Subtract(_lastFired).TotalSeconds;

        if (timeSinceLastBullet >= AttackRatio) // might not work?
            TargetEnemy();
    }

    private void TargetEnemy() // might also be bad.
    {
        Target = (Target != null) && Vector2.Distance(Tile.Position, Target.Position) <= Radius
            ? Target
            : FindTarget();

        if (Target == null)
            return;

        LaneController.Simulator.GameHandler.CommandHandler.QueueCommand(
            TCmdSpawnProjectile.Construct(
                LaneController.Player.ID.ToString(),
                TowerKey.ToString(),
                Target.Key.ToString()),
            LaneController.Player);

        Target.TakeDamage(Damage);
        _lastFired = DateTime.Now;
    }

    // probably bad?
    private Unit FindTarget() => LaneController.Units.Values // Always picks the unit that's furthest towards the goal.
        .Where(x => Vector2.Distance(Tile.Position, x.Position) <= Radius)
        .AsParallel()
        .OrderBy(x => x.CurrentWayPointDestination)
        .FirstOrDefault();

    public ITower Clone() => MemberwiseClone() as ITower;
}