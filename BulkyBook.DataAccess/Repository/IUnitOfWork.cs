﻿using BulkyBook.DataAccess.Repository;

namespace BulkyBook.DataAccess;

public interface IUnitOfWork
{
  ICategoryRepository Category { get; set; }
  void Save();
}

