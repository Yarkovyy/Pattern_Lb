using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lb1.model
{
    internal class Quiz
    {
        public string QuizTitle { get; set; }
        public List<Question> Questions { get; set; }
        public Quiz Clone()
        {
            var json = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Quiz>(json)!;
        }
    }
}
