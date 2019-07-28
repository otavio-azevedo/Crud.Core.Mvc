﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
	public class Seller
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
		public double BaseSalary { get; set; }
		//Cada vendedor tem um Department
		public Department Department { get; set; }
		//Cada vendedor tem uma lista de SalesRecord
		public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

		//Construtor sem argumentos é necessário quando há outro construtor com argumentos;
		public Seller()
		{
		}

		public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
		{
			Id = id;
			Name = name;
			Email = email;
			BirthDate = birthDate;
			BaseSalary = baseSalary;
			Department = department;
		}

		public void AddSales(SalesRecord sr)
		{
			Sales.Add(sr);
		}

		public void RemoveSales(SalesRecord sr)
		{
			Sales.Remove(sr);
		}

		public double TotalSales(DateTime initial, DateTime final)
		{
			return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
		}
	}
}
