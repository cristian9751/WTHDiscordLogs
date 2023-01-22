using Exiled.API.Features;
using HarmonyLib;
using MEC;
using WebhookLogs.API;

namespace WebhookLogs
{
    public class WebhookLogs : Plugin<Config>
    {
        private EventHandlers EventHandlers;

        public static WebhookLogs Singleton;

        private Harmony harmony;
        public override void OnEnabled()
        {
            if (Config.Webhooks.Values == null)
            {
                Log.Warn("Debes indicar las url para los webhooks");
            }

            Singleton = this;
            harmony = new Harmony("webhooklogs");
            EventHandlers = new EventHandlers();

            Exiled.Events.Handlers.Map.Decontaminating += EventHandlers.OnDecontaminating;
            Exiled.Events.Handlers.Player.ActivatingGenerator += EventHandlers.OnActivatingGenerator;
            Exiled.Events.Handlers.Warhead.Starting += EventHandlers.OnStartingWarhead;
            Exiled.Events.Handlers.Warhead.Stopping += EventHandlers.OnStoppingWarhead;
            Exiled.Events.Handlers.Warhead.Detonated += EventHandlers.OnWarheadDetonated;
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandlers.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded += EventHandlers.OnRoundEnded;
            Exiled.Events.Handlers.Server.RespawningTeam += EventHandlers.OnRespawningTeam;
            Exiled.Events.Handlers.Scp914.ChangingKnobSetting += EventHandlers.OnChangingScp914KnobSetting;
            Exiled.Events.Handlers.Player.UsingItem += EventHandlers.OnUsedMedicalItem;
            Exiled.Events.Handlers.Scp079.InteractingTesla += EventHandlers.OnInteractingTesla;
            Exiled.Events.Handlers.Player.PickingUpItem += EventHandlers.OnPickingUpItem;
            Exiled.Events.Handlers.Scp079.GainingLevel += EventHandlers.OnGainingLevel;
            Exiled.Events.Handlers.Player.EscapingPocketDimension += EventHandlers.OnEscapingPocketDimension;
            Exiled.Events.Handlers.Player.EnteringPocketDimension += EventHandlers.OnEnteringPocketDimension;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel += EventHandlers.OnActivatingWarheadPanel;
            Exiled.Events.Handlers.Player.TriggeringTesla += EventHandlers.OnTriggeringTesla;
            Exiled.Events.Handlers.Player.ThrownProjectile += EventHandlers.OnThrowingGrenade;
            Exiled.Events.Handlers.Player.Hurting += EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.Dying += EventHandlers.OnDying;
            Exiled.Events.Handlers.Player.InteractingDoor += EventHandlers.OnInteractingDoor;
            Exiled.Events.Handlers.Player.InteractingElevator += EventHandlers.OnInteractingElevator;
            Exiled.Events.Handlers.Player.InteractingLocker += EventHandlers.OnInteractingLocker;
            Exiled.Events.Handlers.Player.IntercomSpeaking += EventHandlers.OnIntercomSpeaking;
            Exiled.Events.Handlers.Player.Handcuffing += EventHandlers.OnHandcuffing;
            Exiled.Events.Handlers.Player.RemovingHandcuffs += EventHandlers.OnRemovingHandcuffs;
            Exiled.Events.Handlers.Scp106.Teleporting += EventHandlers.OnTeleporting;
            Exiled.Events.Handlers.Player.DroppingItem += EventHandlers.OnItemDropped;
            Exiled.Events.Handlers.Player.Verified += EventHandlers.OnVerified;
            Exiled.Events.Handlers.Player.Destroying += EventHandlers.OnDestroying;
            Exiled.Events.Handlers.Player.ChangingRole += EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Player.ChangingItem += EventHandlers.OnChangingItem;
            Exiled.Events.Handlers.Scp914.Activating += EventHandlers.OnActivatingScp914;
            Exiled.Events.Handlers.Player.DroppingAmmo += EventHandlers.OnDroppingAmmo;
            Exiled.Events.Handlers.Player.Banning += EventHandlers.OnBanning;

            harmony.PatchAll();

            Timing.RunCoroutine(WebhookSender.ManageQueue());
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Map.Decontaminating -= EventHandlers.OnDecontaminating;
            Exiled.Events.Handlers.Player.ActivatingGenerator -= EventHandlers.OnActivatingGenerator;
            Exiled.Events.Handlers.Warhead.Starting -= EventHandlers.OnStartingWarhead;
            Exiled.Events.Handlers.Warhead.Stopping -= EventHandlers.OnStoppingWarhead;
            Exiled.Events.Handlers.Warhead.Detonated -= EventHandlers.OnWarheadDetonated;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandlers.OnWaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStarted;
            Exiled.Events.Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnded;
            Exiled.Events.Handlers.Server.RespawningTeam -= EventHandlers.OnRespawningTeam;
            Exiled.Events.Handlers.Scp914.ChangingKnobSetting -= EventHandlers.OnChangingScp914KnobSetting;
            Exiled.Events.Handlers.Player.UsingItem -= EventHandlers.OnUsedMedicalItem;
            Exiled.Events.Handlers.Scp079.InteractingTesla -= EventHandlers.OnInteractingTesla;
            Exiled.Events.Handlers.Player.PickingUpItem -= EventHandlers.OnPickingUpItem;
            Exiled.Events.Handlers.Scp079.GainingLevel -= EventHandlers.OnGainingLevel;
            Exiled.Events.Handlers.Player.EscapingPocketDimension -= EventHandlers.OnEscapingPocketDimension;
            Exiled.Events.Handlers.Player.EnteringPocketDimension -= EventHandlers.OnEnteringPocketDimension;
            Exiled.Events.Handlers.Player.ActivatingWarheadPanel -= EventHandlers.OnActivatingWarheadPanel;
            Exiled.Events.Handlers.Player.TriggeringTesla -= EventHandlers.OnTriggeringTesla;
            Exiled.Events.Handlers.Player.ThrownProjectile -= EventHandlers.OnThrowingGrenade;
            Exiled.Events.Handlers.Player.Hurting -= EventHandlers.OnHurting;
            Exiled.Events.Handlers.Player.Dying -= EventHandlers.OnDying;
            Exiled.Events.Handlers.Player.InteractingDoor -= EventHandlers.OnInteractingDoor;
            Exiled.Events.Handlers.Player.InteractingElevator -= EventHandlers.OnInteractingElevator;
            Exiled.Events.Handlers.Player.InteractingLocker -= EventHandlers.OnInteractingLocker;
            Exiled.Events.Handlers.Player.IntercomSpeaking -= EventHandlers.OnIntercomSpeaking;
            Exiled.Events.Handlers.Player.Handcuffing -= EventHandlers.OnHandcuffing;
            Exiled.Events.Handlers.Player.RemovingHandcuffs -= EventHandlers.OnRemovingHandcuffs;
            Exiled.Events.Handlers.Scp106.Teleporting -= EventHandlers.OnTeleporting;
            Exiled.Events.Handlers.Player.DroppingItem -= EventHandlers.OnItemDropped;
            Exiled.Events.Handlers.Player.Verified -= EventHandlers.OnVerified;
            Exiled.Events.Handlers.Player.Destroying -= EventHandlers.OnDestroying;
            Exiled.Events.Handlers.Player.ChangingRole -= EventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Player.ChangingItem -= EventHandlers.OnChangingItem;
            Exiled.Events.Handlers.Scp914.Activating -= EventHandlers.OnActivatingScp914;
            Exiled.Events.Handlers.Player.Banning -= EventHandlers.OnBanning;
            harmony.UnpatchAll(harmony.Id);
            harmony = null;
            EventHandlers = null;
            Singleton = null;

        }
    }
}
