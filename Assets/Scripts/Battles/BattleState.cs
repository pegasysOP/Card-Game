public enum BattleState
{
    None,
    Starting,
    Ending,

    // for when non card related things are going on (i.e turn counter animation)
    Idle,

    // I'm thinking 'processing' can be for anything involving changing of the hand (i.e drawing, discarding)
    Processing,

    // When selecting a card
    Selection,

    // 'play' can include anything to do with using a card from the hand (maybe we can have substates to help specify further)
    Playing
}
