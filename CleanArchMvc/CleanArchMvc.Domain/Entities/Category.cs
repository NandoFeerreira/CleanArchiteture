﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities;

public sealed class Category : Entity
{   
    public string Name { get; private set; } = string.Empty;
    

    public ICollection<Product> Products { get; set; }

    #region [ CONSTRUTORES ]

    public Category(string name)
    {
        ValidateDomain(name);
    }

    public Category(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(name);
    }

    #endregion

    #region [ VALIDATIONS ]
    public void Update(string name)
    {
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), 
            "Invalid, name.Name is required");

        DomainExceptionValidation.When(name.Length < 3,
            "Invalid name, to short, minimum 3 characters");

        Name = name;

    }
    #endregion
}
