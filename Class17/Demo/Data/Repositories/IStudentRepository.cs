﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Models;
using Demo.Models.Api;

namespace Demo.Data.Repositories
{

    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTO>> GetAllStudents();

        Task<StudentDTO> GetOneStudent(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns>student exists or not</returns>
        Task<bool> UpdateStudent(long id, Student student);

        Task<StudentDTO> SaveNewStudent(Student student);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>student that was deleted</returns>
        Task<StudentDTO> DeleteStudent(long id);
    }
}
