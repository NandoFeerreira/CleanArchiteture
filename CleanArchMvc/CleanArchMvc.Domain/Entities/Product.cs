﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {     
        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public decimal Price { get; private set; }

        public int Stock { get; private set; }
        public int? terste { get; private set; }

        public string Image { get; private set; } = string.Empty;

        public int CategoryId { get;  set; }   

        public Category Category { get; set; }

        #region [ CONSTRUTORES ]

        public Product
            (
                string name,
                string description,
                decimal price,
                int stock,
                string image
            )
        {
            ValidadeDomain
            (
                name:name,
                description: description,
                price:price, 
                stock:stock,
                image:image
             );
        }

        public Product
           (
               int id, 
               string name,
               string description,
               decimal price,
               int stock,
               string image
           )
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");

            Id = id;

            ValidadeDomain
            (
                name: name,
                description: description,
                price: price,
                stock: stock,
                image: image
             );
        }

        public void Update
           (
               string name,
               string description,
               decimal price,
               int stock,
               string image,
               int categoryId
           )
        {
            ValidadeDomain
            (
                name: name,
                description: description,
                price: price,
                stock: stock,
                image: image
             );

            CategoryId = categoryId;
        }

        #endregion

        #region [ VALIDATION ]
        private void ValidadeDomain
            (
                string name,
                string description,
                decimal price,
                int stock, 
                string image 
            )
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. name is required ");

            DomainExceptionValidation.When(name.Length < 3,
               "Invalid name. to short, minimum 3 characters ");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid descricao. descricao is required ");

            DomainExceptionValidation.When(description.Length < 5,
                "Invalid descricao.to short, minimum 3 characters");           

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250,
               "Invalid image name. too long   maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }

        #endregion
    }
}
