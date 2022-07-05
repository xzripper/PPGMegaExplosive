using UnityEngine;

namespace MegaExplosive {
    public class MegaExplosiveBehaviour : MonoBehaviour {
        public static void Main() {
            ModAPI.Register(
                new Modification() {
                    OriginalItem = ModAPI.FindSpawnable("Brick"),
                    NameOverride = "Mega Explosive! -MegaExplosive",
                    DescriptionOverride = "Explosive that explodes all! :D",
                    CategoryOverride = ModAPI.FindCategory("Explosives"),
                    ThumbnailOverride = ModAPI.LoadSprite("textures/explosive.png"),

                    AfterSpawn = (Instance) => {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("textures/explosive.png");
                        Instance.FixColliders();

                        Instance.AddComponent<UseEventTrigger>().Action = () => {
                            ExplosionCreator.Explode(
                                new ExplosionCreator.ExplosionParameters {
                                    Position = Instance.transform.position,
                                    CreateParticlesAndSound = true,
                                    LargeExplosionParticles = true,
                                    DismemberChance = 1.0f,
                                    FragmentForce = 64,
                                    FragmentationRayCount = 64,
                                    Range = 64
                                }
                            );

                            Destroy(Instance);
                        };
                    }
                }
            );
        }
    }
}
