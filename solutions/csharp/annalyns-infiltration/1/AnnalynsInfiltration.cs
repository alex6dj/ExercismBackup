using System;
using System.Diagnostics;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        return !knightIsAwake;
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        return knightIsAwake || archerIsAwake || prisonerIsAwake;
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        return !archerIsAwake && prisonerIsAwake;
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake,
        bool petDogIsPresent)
        => (knightIsAwake, archerIsAwake, prisonerIsAwake, petDogIsPresent) switch
        {
            (false, false, false, true) => true,
            (true, false, _, true) => true,
            (false, false, true, _) => true,
            (false, false, false, false) => false,
            (true, true, true, _) => false,
            (true, false, true, false) => false,
            (false, true, _, true) => false,
            (true, false, false, false) => false,
            (true, true, false, _) => false,
            (false, true, _, false) => false,
        };


}
