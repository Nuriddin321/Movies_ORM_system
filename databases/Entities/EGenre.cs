namespace databases.Entities;
 

[Flags]
public enum EGenre : short
{
    None = 0,
    Action = 1,
    Horror = 2,
    Thriller = 4,
    Comedy = 8,
    Romance = 16,
    History = 32,
    SiFi = 64
}