namespace Lection11Interface2;

public interface IFeatureDescription
{
    Type GetFeatureInterface();
    Type GetFeatureType();
    string GetFeatureDescription();
}

public interface IPluginInfo
{
    List<IFeatureDescription> Features { get    ; }
}

