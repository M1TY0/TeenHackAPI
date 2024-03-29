﻿namespace TeenHackAPI.Models
{
    public enum PartOfTheDay
    {
        Morning,
        Evening,
        Lunch,
        EveryTime
    }
    public enum Type
    {
        breading,
        meditation
    }
    public enum Purpose
    {
        stressrelieve,
        mindfullness,
        focus
    }
    public class Exercises
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string videoLink { get; set; }
        public string photoLink { get; set; }
        public PartOfTheDay partOfTheDay { get; set; }
        public Type type { get; set; }
        public  Purpose purpose { get ;set;}
        public string moreinfo { get; set; }
    }
    public class ExerciseResponse
    {
        public  Models.Exercises[] result { get; set; }
    }
    public class ExerciseResponseMed
    {
        public List<Models.Exercises> result { get; set; }
    }
}