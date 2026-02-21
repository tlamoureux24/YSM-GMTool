namespace App.Core.Models;

public sealed class TableNameSettings
{
    public string ArcadiaName { get; set; } = "Arcadia";

    public string TelecasterName { get; set; } = "Telecaster";

    public string AuthName { get; set; } = "Auth";

    public string AccountsName { get; set; } = "Accounts";

    public string CharacterResource { get; set; } = "CharacterResource";

    public string MonsterResource { get; set; } = "MonsterResource";

    public string StringResource { get; set; } = "StringResource";

    public string ItemResource { get; set; } = "ItemResource";

    public string SkillResource { get; set; } = "SkillResource";

    public string StateResource { get; set; } = "StateResource";

    public string NpcResource { get; set; } = "NpcResource";

    public string SummonResource { get; set; } = "SummonResource";

    public IReadOnlyDictionary<string, string> ToTokenMap()
    {
        var map = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            [nameof(ArcadiaName)] = ArcadiaName,
            [nameof(TelecasterName)] = TelecasterName,
            [nameof(AuthName)] = AuthName,
            [nameof(AccountsName)] = AccountsName,
            [nameof(CharacterResource)] = CharacterResource,
            [nameof(MonsterResource)] = MonsterResource,
            [nameof(StringResource)] = StringResource,
            [nameof(ItemResource)] = ItemResource,
            [nameof(SkillResource)] = SkillResource,
            [nameof(StateResource)] = StateResource,
            [nameof(NpcResource)] = NpcResource,
            [nameof(SummonResource)] = SummonResource
        };

        foreach (var (key, value) in map.ToArray())
        {
            map[key] = string.IsNullOrWhiteSpace(value) ? key : value.Trim();
        }

        return map;
    }

    public TableNameSettings Clone() => new()
    {
        ArcadiaName = ArcadiaName,
        TelecasterName = TelecasterName,
        AuthName = AuthName,
        AccountsName = AccountsName,
        CharacterResource = CharacterResource,
        MonsterResource = MonsterResource,
        StringResource = StringResource,
        ItemResource = ItemResource,
        SkillResource = SkillResource,
        StateResource = StateResource,
        NpcResource = NpcResource,
        SummonResource = SummonResource
    };
}
