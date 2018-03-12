using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Consts
{
    public const int TexturePixelsPerUnit = 100;

    // https://en.wikipedia.org/wiki/Machine_epsilon
    // pow(2, -24) -> 5.96e-08, magic minimal number
    public static readonly float Epsilon_Float = 5.96e-08f;

    public static readonly float Sprite_Gap_Time = 1.0f / 12.0f;

    public static readonly string Template_Tk2dSprite = "tk2dSprite_template";
    public static readonly string Template_Character = "tk2dSprite_character_template";
    public static readonly string Template_Monster = "tk2dSprite_monster_template";

    public static readonly string Template_PathFinding_Target = "pathfinding_target_template";
    public static readonly string Template_PathFinding_Seeker = "pathfinding_seeker_template";

    public static readonly string ID_HERO_ARCHER = "heroes_archer";
    public static readonly string ID_HERO_PHOENIX = "heroes_phoenix";
    public static readonly string ID_HERO_PANDA = "heroes_panda";

    // Asset names
    public const string ASSET_NAME_CHARACTER = "character";

    // Tags
    public const string TAG_PLAYER = "Player";
    public const string TAG_MAIN_CAMERA = "MainCamera";

    // State Machine
    public static readonly string STRING_FSM_RUN = "Run";

    // TODO Enum Dictionay still has GC
    public static Dictionary<CharacterState, string> StateStringCache = new Dictionary<CharacterState, string>(8);

    static Consts()
    {
        StateStringCache.Add(CharacterState.Idle, CharacterState.Idle.ToString());
        StateStringCache.Add(CharacterState.Run, CharacterState.Run.ToString());
        StateStringCache.Add(CharacterState.LightAttack1, CharacterState.LightAttack1.ToString());
        StateStringCache.Add(CharacterState.LightAttack2, CharacterState.LightAttack2.ToString());
        StateStringCache.Add(CharacterState.HeavyAttack1, CharacterState.HeavyAttack1.ToString());
        StateStringCache.Add(CharacterState.HeavyAttack2, CharacterState.HeavyAttack2.ToString());
        StateStringCache.Add(CharacterState.LevelUp, CharacterState.LevelUp.ToString());
        StateStringCache.Add(CharacterState.Die, CharacterState.Die.ToString());
    }
}
