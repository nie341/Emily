//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public PathFindingToPositionComponent pathFindingToPosition { get { return (PathFindingToPositionComponent)GetComponent(InputComponentsLookup.PathFindingToPosition); } }
    public bool hasPathFindingToPosition { get { return HasComponent(InputComponentsLookup.PathFindingToPosition); } }

    public void AddPathFindingToPosition(float newX, float newY) {
        var index = InputComponentsLookup.PathFindingToPosition;
        var component = CreateComponent<PathFindingToPositionComponent>(index);
        component.x = newX;
        component.y = newY;
        AddComponent(index, component);
    }

    public void ReplacePathFindingToPosition(float newX, float newY) {
        var index = InputComponentsLookup.PathFindingToPosition;
        var component = CreateComponent<PathFindingToPositionComponent>(index);
        component.x = newX;
        component.y = newY;
        ReplaceComponent(index, component);
    }

    public void RemovePathFindingToPosition() {
        RemoveComponent(InputComponentsLookup.PathFindingToPosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IPathFindingToPositionEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPathFindingToPosition;

    public static Entitas.IMatcher<InputEntity> PathFindingToPosition {
        get {
            if (_matcherPathFindingToPosition == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PathFindingToPosition);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPathFindingToPosition = matcher;
            }

            return _matcherPathFindingToPosition;
        }
    }
}
