﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public class MemoryRepository : IRepositiory
    {
        private Dictionary<int, Reservation> items;

        public MemoryRepository()
        {
            items = new Dictionary<int, Reservation>();
            new List<Reservation>
            {
                new Reservation() {ClientName = "Alice", Location = "Board Room"},
                new Reservation() {ClientName = "Bob", Location = "Lecture hall"},
                new Reservation() {ClientName = "Joe", Location = "Meeting room 1"}
            }.ForEach(r=>AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;
        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation AddReservation(Reservation reservation)
        {
            if (reservation.ReservationId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key))
                {
                    key++;
                }
                reservation.ReservationId = key;
                items[reservation.ReservationId] = reservation;
            }
            return reservation;
        }

        public void DeleteReservation(int id) => items.Remove(id);
        public Reservation UpdateReservation(Reservation reservation) => AddReservation(reservation);
    }
}
