using System.ComponentModel;

namespace TaskSystem.Enums
{
    public enum TaskStatus
    {
        [Description("A fazer")]
        ToDo = 1,
        [Description("Em progresso")]
        Running = 2,
        [Description("Finalizado")]
        Finished = 3
    }
}
