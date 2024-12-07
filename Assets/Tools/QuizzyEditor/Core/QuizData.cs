using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGraphEditor
{
    [Serializable]
    public class EdgeData
    {
        public string outputNodeGUID { get; set; }
        public string outputPortName { get; set; }
        public string inputNodeGUID { get; set; }
        public string inputPortName { get; set; }
    }

    [Serializable]
    public class QuizData
    {
        public List<MultipleChoiceNodeData> multipleChoiceNodes = new List<MultipleChoiceNodeData>();
        public List<TrueFalseNodeData> trueFalseNodes = new List<TrueFalseNodeData>();
        public StartNodeData startNodeData;
        public List<EdgeData> edges = new List<EdgeData>();
    }

    [Serializable]
    public class BaseQuestionNodeData
    {
        public string GUID;
        public string QuestionText;
        public string Category;
        public Difficulty DifficultyLevel;
        public float TimeLimit;
        public int PointValue;
        public string Explanation;
        public Vector2 Position;
    }


    [Serializable]
    public class StartNodeData
    {
        public string GUID;
        internal Vector2 Position;
    }

    [Serializable]
    public class MultipleChoiceNodeData : BaseQuestionNodeData
    {
        public string[] Answers;
        public int CorrectAnswerIndex;
    }

    [Serializable]
    public class TrueFalseNodeData : BaseQuestionNodeData
    {
        public string[] Answers;
        public int CorrectAnswerIndex;
    }
}