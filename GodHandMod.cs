bin/
obj.
.vs/
using BepInEx;
using UnityEngine;

namespace GodHandMod
{
    [BepInPlugin("com.yourdirectory.godhand", "God Hand Mod", "1.0.0")]
    public class GodHand : BaseUnityPlugin
    {
        private bool isActive = false;

        void Update()
        {
            // F tuşuna basınca gücü aç/kapat
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (!isActive)
                {
                    ActivatePower();
                }
                else
                {
                    DeactivatePower();
                }
            }
        }

        void ActivatePower()
        {
            isActive = true;
            Player.m_localPlayer.m_damageModifier = 1.5f;  // Verilen hasar 1.5 kat
            Player.m_localPlayer.m_damageTakenModifier = 0.75f; // Alınan hasar %25 azalır
            Player.m_localPlayer.Message(MessageHud.MessageType.TopLeft, "Tanrının Eli Aktif! (Sınırsız)");
        }

        void DeactivatePower()
        {
            isActive = false;
            Player.m_localPlayer.m_damageModifier = 1f;    // Normal hasara dön
            Player.m_localPlayer.m_damageTakenModifier = 1f;
            Player.m_localPlayer.Message(MessageHud.MessageType.TopLeft, "Tanrının Eli Kapatıldı.");
        }
    }
}
