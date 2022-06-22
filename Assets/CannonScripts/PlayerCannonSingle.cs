using UnityEngine;

namespace GameLogic
{
    public sealed class PlayerCannonSingle : PlayerCannon
    {
        [SerializeField] private Transform _bulletStartPosition;
        public override void Shot()
        {
            BulletActivate(_bulletStartPosition);
        }
    }
}
