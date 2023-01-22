using System;
using Core.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Warhead;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.EventArgs.Scp914;
using Exiled.Events.EventArgs.Scp079;
using Exiled.Events.EventArgs.Scp106;
using WebhookLogs.API;

namespace WebhookLogs
{
    class EventHandlers
    {
        public void OnDecontaminating(DecontaminatingEventArgs ev)
        {
            WebhookSender.AddMessage("DESCONTAMINACION: Se ha activado la descontaminacion", WebhookType.GameLogs);
        }

        public void OnActivatingGenerator(ActivatingGeneratorEventArgs ev)
        {
            WebhookSender.AddMessage($"GENERADORES: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha activado un generador en {ev.Generator.Room.Name}", WebhookType.GameLogs);
        }

        public void OnStartingWarhead(StartingEventArgs ev)
        {
            WebhookSender.AddMessage($"WARHEAD: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha activado la warhead y va a detonar en {Exiled.API.Features.Warhead.DetonationTimer}", WebhookType.GameLogs);
        }

        public void OnStoppingWarhead(StoppingEventArgs ev)
        {
            WebhookSender.AddMessage($"WARHEAD: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name} ha desactivado la warhead con {Exiled.API.Features.Warhead.DetonationTimer})", WebhookType.GameLogs);
        }

        public void OnWarheadDetonated()
        {
            WebhookSender.AddMessage("WARHEAD: Se ha detonado la ALpha Warhead ", WebhookType.GameLogs);
        }

        public void OnWaitingForPlayers()
        {
            WebhookSender.AddMessage("SERVIDOR: Iniciando ronda...", WebhookType.JoinLogs);
        }

        public void OnRoundStarted()
        {
            WebhookSender.AddMessage("SERVIDOR: Se ha iniciado una ronda.", WebhookType.JoinLogs);
        }

        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            WebhookSender.AddMessage($"GANADOR: Ha finalizado una ronda y ha ganado {ev.LeadingTeam}", WebhookType.JoinLogs);
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            WebhookSender.AddMessage($"SPAWN: Han spawneado {ev.SpawnableTeam}", WebhookType.GameLogs);
        }

        public void OnChangingScp914KnobSetting(ChangingKnobSettingEventArgs ev)
        {
            WebhookSender.AddMessage($"914: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name} ha cambiado el switch de la 914 a {ev.KnobSetting})", WebhookType.GameLogs);
        }

        public void OnUsedMedicalItem(UsedItemEventArgs ev)
        {
            WebhookSender.AddMessage($"ITEM: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha cogido {ev.Item}", WebhookType.GameLogs);
        }

        public void OnInteractingTesla(InteractingTeslaEventArgs ev)
        {
           WebhookSender.AddMessage($"SCP079: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha activado un tesla en {ev.Tesla.Room.Name}", WebhookType.GameLogs);
        }

        public void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            WebhookSender.AddMessage($"ITEMS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha cogido {ev.Pickup.Type}", WebhookType.GameLogs);
        }

        public void OnGainingLevel(GainingLevelEventArgs ev)
        {
            WebhookSender.AddMessage($"SCP079: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name} ha subido de nivel a {ev.NewLevel})", WebhookType.GameLogs);
        }

        public void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            WebhookSender.AddMessage($"DIMENSION: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha escapado de la dimension de bolsillo", WebhookType.GameLogs);
        }

        public void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev)
        {
            WebhookSender.AddMessage($"DIMENSION: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha entrado en la dimension de bolsillo", WebhookType.GameLogs);
        }

        public void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            WebhookSender.AddMessage($"WARHEAD: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha abierto el cover del boton de detonacion de la warhead", WebhookType.GameLogs);
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            WebhookSender.AddMessage($"TESLA: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha pasado un tesla en {ev.Tesla.Room.Name}", WebhookType.GameLogs);
        }

        public void OnThrowingGrenade(ThrownProjectileEventArgs ev)
        {
            WebhookSender.AddMessage($"ITEMS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha lanzado {ev.Throwable.Type}", WebhookType.GameLogs);
        }

        public void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Player is null || ev.Attacker is null || ev.DamageHandler is null)
                return;
            WebhookSender.AddMessage($"HERDA: {ev.Attacker.Nickname} - {ev.Attacker.UserId} ({ev.Attacker.Role.Name}) ha dañado a {ev.Player.Nickname} - {ev.Player.UserId}({ev.Player.Role.Name}) por {ev.Amount} con {ev.DamageHandler.Type}", WebhookType.KillLogs);
        }

        public void OnDying(DyingEventArgs ev)
        {
            if (ev.Player is null || ev.Attacker is null)
                return;
            WebhookSender.AddMessage($"MUERTE:{ev.Attacker.Nickname} - {ev.Attacker.UserId} ({ev.Attacker.Role.Name}) ha matado a {ev.Player.Nickname} - {ev.Player.UserId}({ev.Player.Role.Name}) con {ev.DamageHandler.Type}", WebhookType.KillLogs);
        }

        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            WebhookSender.AddMessage($"PUERTAS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha abierto {ev.Door.Nametag} en {ev.Door.Room.Name}", WebhookType.GameLogs);
        }

        public void OnInteractingElevator(InteractingElevatorEventArgs ev)
        {
            WebhookSender.AddMessage($"ASCENSORES: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha usado un ascensor", WebhookType.GameLogs);
        }

        public void OnInteractingLocker(InteractingLockerEventArgs ev)
        {
            WebhookSender.AddMessage($"TAQULLAS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha abierto una taquilla", WebhookType.GameLogs);
        }

        public void OnIntercomSpeaking(IntercomSpeakingEventArgs ev)
        {
            WebhookSender.AddMessage($"INTERCOM: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha comenzado a hablar por intercom", WebhookType.GameLogs);
        }

        public void OnHandcuffing(HandcuffingEventArgs ev)
        {
            WebhookSender.AddMessage($"ESPOSAR: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha esposado a {ev.Target.Nickname} - {ev.Target.UserId} ({ev.Target.Role.Name})", WebhookType.GameLogs);
        }

        public void OnRemovingHandcuffs(RemovingHandcuffsEventArgs ev)
        {
            WebhookSender.AddMessage($"ESPOSAR: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha desesposado a {ev.Target.Nickname} - {ev.Target.UserId} ({ev.Target.Role.Name})", WebhookType.GameLogs);
        }

        public void OnTeleporting(TeleportingEventArgs ev)
        {
            WebhookSender.AddMessage($"SCP106: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name} se ha teletransportado como 106)", WebhookType.GameLogs);
        }

        public void OnItemDropped(DroppingItemEventArgs ev)
        {
            WebhookSender.AddMessage($"ITEMS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha tirado {ev.Item.Type}", WebhookType.GameLogs);
        }

        public void OnVerified(VerifiedEventArgs ev)
        {
            WebhookSender.AddMessage($"UNIDO: {ev.Player.Nickname} - {ev.Player.UserId} con la ip {ev.Player.IPAddress} se ha unido al servidor", WebhookType.JoinLogs);
        }

        public void OnDestroying(DestroyingEventArgs ev)
        {
            string tipo = "";
           if(ev.Player.IsAlive)
            {
                tipo = "DESCONECTADO EN PARTIDA";
            } else
            {
                tipo = "DESCONECTADO MUERTO";
            }

            WebhookSender.AddMessage($"{tipo}: {ev.Player.Nickname} - {ev.Player.UserId} ha abandanoda el servidor como {ev.Player.Role.Name}", WebhookType.JoinLogs);
            tipo = null;
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            WebhookSender.AddMessage($"{ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha cambiado de rol a {ev.NewRole}", WebhookType.GameLogs);
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
           WebhookSender.AddMessage($"{ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha  cambiado el item de su mano a {ev.NewItem} ", WebhookType.GameLogs);
        }

        public void OnActivatingScp914(ActivatingEventArgs ev)
        {
            WebhookSender.AddMessage($"{ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha activado la 914", WebhookType.GameLogs);
        }

        public void OnDroppingAmmo(DroppingAmmoEventArgs ev)
        {
            WebhookSender.AddMessage($"ITEMS: {ev.Player.Nickname} - {ev.Player.UserId} ({ev.Player.Role.Name}) ha tirado {ev.Amount} municion de tipo {ev.AmmoType}", WebhookType.GameLogs);
        }

        public void OnBanning( BanningEventArgs ev)
        {
            Map.Broadcast(5, $"{ev.Player.Nickname} ha baneado a {ev.Target.Nickname} por {ev.Reason} durante {ev.Duration} minutos");
            String message = "----------BAN----------" + "\n" +
                             "**Usuario baneado: **" + ev.Target.Nickname + "\n" +
                             "**Baneado por: **" + ev.Player.Nickname + "\n" +
                             "**Razón del baneo: **" + ev.Reason + "\n" +
                             "**Duración: **" + ev.Duration;
           WebhookSender.AddMessage(message, WebhookType.BanLogs);
           message = null;
        }
    } 
}
