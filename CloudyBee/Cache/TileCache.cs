namespace CloudyBeeEngine.Cache
{
    public static class TileCache
    {
        /*  private static Cache<Tile> cache;

          internal static Cache<Tile> Cache
          {
              get
              {
                  if (cache == null)
                  {
                      cache = new Cache<Tile>();
                  }

                  return cache;
              }
        
        }

          public static void Initialise(List<Addon> addons)
          {
              foreach (Addon addon in addons)
              {
                  List<string> files = new List<string>();

                  string path = Path.Combine(addon.Directory, Constants.PATH_TEXTURE_CACHE);
                  Helper.GetAllFiles(path, ref files);

                  files.ForEach(x => LoadTextureFromFile(x, graphics));
              }
          }

          private static void LoadTileFromFile(string file)
          {
              Tile tile = null;
              string itemName = Helper.GetPathFromDirectory(file, "XML");

              bool success = texture.TryParse(file, graphics, out texture);

              if (success)
              {
                  AddItem(itemName, texture);
              }
              else
              {
                  Logger.Instance.LogError(string.Format("Unable to load Texture from file at path '{0}'.", file));
              }
          }

          public static bool AddItem(string tileName, Tile tile)
          {
              return Cache.AddItem(tileName, tile);
          }

          public static Tile GetItem(string tileName)
          {
              Tile value;

              if (!Cache.GetItem(tileName, out value))
              {
                  value = null;
              }

              return value;
          }*/
    }
}