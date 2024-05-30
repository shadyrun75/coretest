using CoreTest.Models.Enums;

namespace CoreTest.Models.Common
{
    public class ActionElement
    {
        public int Priority {  get; set; }
        public ActionType Type { get; set; }
        public CaseType Case { get; set; }

        public ActionElement(int priority, ActionType type, CaseType @case)
        {
            Priority = priority;
            Type = type;
            Case = @case;
        }
    }
}
