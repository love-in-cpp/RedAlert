using System.Collections.Generic;
using UnityEngine;

public class VistorPattern:MonoBehaviour
{
    private void Start()
    {
        CandidateList list = new CandidateList();
        IJudgeApartment researchJudge = new ResearchJudgement();
        IJudgeApartment gradeJudge = new GradeJudgement();

        ICandidate teacher = new Teacher();
        ICandidate student = new Student();
        list.Add(teacher);
        list.Add(student);
        
        list.Accept(researchJudge);
        list.Accept(gradeJudge);
    }
}

public abstract class ICandidate
{
    public abstract void Accept(IJudgeApartment judgeApartment);
}
public class Teacher:ICandidate
{
    public override void Accept(IJudgeApartment judgeApartment)
    {
        judgeApartment.Judge(this);
    }
}
public class Student:ICandidate
{
    public override void Accept(IJudgeApartment judgeApartment)
    {
        judgeApartment.Judge(this);
    }
}

public abstract class IJudgeApartment
{
    public abstract void Judge(Teacher teacher);
    public abstract void Judge(Student student);
}

public class ResearchJudgement:IJudgeApartment
{
    public override void Judge(Teacher teacher)
    {
        // 判断教师论文
    }

    public override void Judge(Student student)
    {
        // 判断学生论文
    }
}

public class GradeJudgement : IJudgeApartment
{
    public override void Judge(Teacher teacher)
    {
        // 判断教师成绩
    }

    public override void Judge(Student student)
    {
        // 判断学生成绩
    }
}

public class CandidateList
{
    private List<ICandidate> _candidates;

    public CandidateList()
    {
        _candidates = new List<ICandidate>();
    }

    public void Add(ICandidate candidate)
    {
        _candidates.Add(candidate);
    }

    public void Remove(ICandidate candidate)
    {
        _candidates.Remove(candidate);
    }

    public void Accept(IJudgeApartment apartment)
    {
        foreach (var candidate in _candidates)
        {
            candidate.Accept(apartment);
        }
    }
}