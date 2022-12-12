﻿namespace SiKoperasi.AppService.Dto.Member
{
    public class JobEditDto
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string JobName { get; set; }
        public string Company { get; set; }
        public string? JobPosition { get; set; }
        public string? JobDescription { get; set; }
        public DateTime StartDate { get; set; }
    }
}
