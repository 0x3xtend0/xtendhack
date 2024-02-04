using UnityEngine;

namespace xtendhack
{
  partial class hack : MonoBehaviour
  {
    private readonly float entity_update_interval = 5f;
    private float entity_update_timer;

        private void EntityUpdate()
        {
            
                if (entity_update_timer <= 0f)
                {
                    enemies = FindObjectsOfType<EnemyAI>();
                    grabbable_objects = FindObjectsOfType<GrabbableObject>();
                    giftBoxItems = FindObjectsOfType<GiftBoxItem>();


                    local_player = HUDManager.Instance.localPlayer;


                    assign_camera();

                    clear_update_timer();
                }

                entity_update_timer -= Time.deltaTime;
            }
        

    private void clear_update_timer()
    {
      entity_update_timer = entity_update_interval;
    }
    private void assign_camera()
    {
      camera = local_player.gameplayCamera;
    }
  }
}