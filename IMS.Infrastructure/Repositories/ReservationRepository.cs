﻿﻿using IMS.Application.DTO;
using IMS.Application.Interfaces;
using IMS.Core.Model;
using IMS.Infrastructure.Services;

namespace IMS.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataBaseContext _dbContext;

        public ReservationRepository(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ItemReservation? GetReservationEntityById(int id)
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.ItemReservationId == id && rsv.IsActive)
                .FirstOrDefault();
        }

        public ItemReservationDetailedDTO? GetReservationDTOById(int id)
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.ItemReservationId == id && rsv.IsActive)
                .Select(rsv => new ItemReservationDetailedDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedClerkId = rsv.RespondedClerkId,
                    respondedClerkName =
                        rsv.RespondedClerk != null
                            ? rsv.RespondedClerk.FirstName + " " + rsv.RespondedClerk.LastName
                            : null,
                    responseNote = rsv.ResponseNote,
                    respondedAt = rsv.RespondedAt,
                    lentClerkId = rsv.LentClerkId,
                    lentClerkName =
                        rsv.LentClerk != null
                            ? rsv.LentClerk.FirstName + " " + rsv.LentClerk.LastName
                            : null,
                    borrowedAt = rsv.BorrowedAt,
                    returnAcceptedClerkId = rsv.ReturnAcceptedClerkId,
                    returnAcceptedClerkName =
                        rsv.ReturnAcceptedClerk != null
                            ? rsv.ReturnAcceptedClerk.FirstName
                                + " "
                                + rsv.ReturnAcceptedClerk.LastName
                            : null,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .FirstOrDefault();
        }

        public List<ItemReservationDTO> GetAllReservationDTOs(int itemId)
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.IsActive && rsv.ItemId == itemId)
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.startDate)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllNonCompletedReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && (
                        rsv.Status == "Pending"
                        || rsv.Status == "Reserved"
                        || rsv.Status == "Borrowed"
                    )
                )
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.createdAt)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllRequestedReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.IsActive && rsv.Status == "Pending")
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.createdAt)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllReservedReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.IsActive && rsv.Status == "Reserved")
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.respondedAt)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllBorrowedReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv => rsv.IsActive && rsv.Status == "Borrowed")
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.borrowedAt)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllBorrowedReservationDTOsByStudent(int studentId)
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive && rsv.ReservedUserId == studentId && rsv.Status == "Borrowed"
                )
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.borrowedAt)
                .ToList();
        }

        public List<ItemReservationDTO> GetAllNonBorrowedReservationDTOsByStudent(int studentId)
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && rsv.ReservedUserId == studentId
                    && (
                        rsv.Status == "Reserved"
                        || rsv.Status == "Rejected"
                        || rsv.Status == "Pending"
                    )
                )
                .Select(rsv => new ItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.createdAt)
                .ToList();
        }

        public ItemReservationDetailedDTO? RequestEquipmentReservation(
            Equipment equipment,
            User student,
            RequestEquipmentDTO requestEquipmentDTO
        )
        {
            ItemReservation reservation = new ItemReservation
            {
                EquipmentId = equipment.EquipmentId,
                Equipment = equipment,
                StartDate = DateTime.Parse(requestEquipmentDTO.startDate),
                EndDate = DateTime.Parse(requestEquipmentDTO.endDate),
                ReservedUserId = student.UserId,
                ReservedUser = student,
                CreatedAt = DateTime.Now,
                Status = "Pending",
                IsActive = true,
            };
            _dbContext.itemReservations.Add(reservation);
            _dbContext.SaveChanges();
            return GetReservationDTOById(reservation.ItemReservationId);
        }

        public ItemReservationDetailedDTO? AcceptEquipmentReservation(
            ItemReservation reservation,
            Item item,
            User clerk
        )
        {
            reservation.ItemId = item.ItemId;
            reservation.Item = item;
            reservation.RespondedClerkId = clerk.UserId;
            reservation.RespondedClerk = clerk;
            reservation.Status = "Reserved";
            reservation.RespondedAt = DateTime.Now;
            _dbContext.Update(reservation);
            _dbContext.SaveChanges();
            return GetReservationDTOById(reservation.ItemReservationId);
        }

        public ItemReservationDetailedDTO? RejectEquipmentReservation(
            ItemReservation reservation,
            User clerk,
            RespondReservationDTO respondReservationDTO
        )
        {
            reservation.RespondedClerkId = clerk.UserId;
            reservation.RespondedClerk = clerk;
            reservation.Status = "Rejected";
            reservation.ResponseNote = respondReservationDTO.rejectNote;
            reservation.RespondedAt = DateTime.Now;
            _dbContext.Update(reservation);
            _dbContext.SaveChanges();
            return GetReservationDTOById(reservation.ItemReservationId);
        }

        public ItemReservationDetailedDTO? BorrowReservedItem(
            ItemReservation reservation,
            Item item,
            User clerk
        )
        {
            reservation.LentClerkId = clerk.UserId;
            reservation.LentClerk = clerk;
            reservation.Status = "Borrowed";
            reservation.BorrowedAt = DateTime.Now;
            item.Status = "Borrowed";
            _dbContext.Update(reservation);
            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return GetReservationDTOById(reservation.ItemReservationId);
        }

        public ItemReservationDetailedDTO? CancelReservation(ItemReservation reservation)
        {
            reservation.Status = "Canceled";
            reservation.CancelledAt = DateTime.Now;
            reservation.IsActive = false;
            _dbContext.Update(reservation);
            _dbContext.SaveChanges();
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.ItemReservationId == reservation.ItemReservationId
                )
                .Select(rsv => new ItemReservationDetailedDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    createdAt = rsv.CreatedAt,
                    respondedClerkId = rsv.RespondedClerkId,
                    respondedClerkName =
                        rsv.RespondedClerk != null
                            ? rsv.RespondedClerk.FirstName + " " + rsv.RespondedClerk.LastName
                            : null,
                    responseNote = rsv.ResponseNote,
                    respondedAt = rsv.RespondedAt,
                    lentClerkId = rsv.LentClerkId,
                    lentClerkName =
                        rsv.LentClerk != null
                            ? rsv.LentClerk.FirstName + " " + rsv.LentClerk.LastName
                            : null,
                    borrowedAt = rsv.BorrowedAt,
                    returnAcceptedClerkId = rsv.ReturnAcceptedClerkId,
                    returnAcceptedClerkName =
                        rsv.ReturnAcceptedClerk != null
                            ? rsv.ReturnAcceptedClerk.FirstName
                                + " "
                                + rsv.ReturnAcceptedClerk.LastName
                            : null,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .FirstOrDefault();
        }

        public ItemReservationDetailedDTO? ReturnBorrowedItem(
            ItemReservation reservation,
            Item item,
            User clerk
        )
        {
            reservation.ReturnAcceptedClerkId = clerk.UserId;
            reservation.ReturnAcceptedClerk = clerk;
            reservation.Status = "Returned";
            reservation.ReturnedAt = DateTime.Now;
            item.Status = "Available";
            _dbContext.Update(reservation);
            _dbContext.Update(item);
            _dbContext.SaveChanges();
            return GetReservationDTOById(reservation.ItemReservationId);
        }

        public bool CheckTimeSlotAvailability(DateTime startDate, DateTime endDate)
        {
            return !_dbContext.itemReservations.Any(rsv =>
                rsv.EndDate >= startDate
                && rsv.StartDate <= endDate
                && rsv.IsActive
                && (rsv.Status == "Reserved" || rsv.Status == "Borrowed")
            );
        }

        public List<DueItemReservationDTO> GetAllDueItemReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && rsv.Status == "Borrowed"
                    && rsv.EndDate.Date.CompareTo(DateTime.Now.Date) <= 0
                )
                .Select(rsv => new DueItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    reservedUserEmail = rsv.ReservedUser.Email,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.endDate)
                .ToList();
        }

        public List<DueItemReservationDTO> GetAllPickupPendingReservationDTOs()
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && rsv.Status == "Reserved"
                    && rsv.StartDate.Date.CompareTo(DateTime.Now.Date) <= 0
                )
                .Select(rsv => new DueItemReservationDTO
                {
                    reservationId = rsv.ItemReservationId,
                    equipmentId = rsv.EquipmentId,
                    itemName = rsv.Equipment.Name,
                    itemModel = rsv.Equipment.Model,
                    imageUrl = rsv.Equipment.ImageURL,
                    itemId = rsv.ItemId,
                    itemSerialNumber = rsv.Item != null ? rsv.Item.SerialNumber : null,
                    labId = rsv.Equipment.LabId,
                    labName = rsv.Equipment.Lab.LabName,
                    startDate = rsv.StartDate,
                    endDate = rsv.EndDate,
                    reservedUserId = rsv.ReservedUserId,
                    reservedUserName = rsv.ReservedUser.FirstName + " " + rsv.ReservedUser.LastName,
                    reservedUserEmail = rsv.ReservedUser.Email,
                    createdAt = rsv.CreatedAt,
                    respondedAt = rsv.RespondedAt,
                    borrowedAt = rsv.BorrowedAt,
                    returnedAt = rsv.ReturnedAt,
                    cancelledAt = rsv.CancelledAt,
                    status = rsv.Status,
                })
                .OrderByDescending(rsv => rsv.startDate)
                .ToList();
        }

        public List<EquipmentReservationsCountForMonthDTO> GetReservationsCountForMonth(int year, int month)
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && rsv.StartDate.Year == year
                    && rsv.StartDate.Month == month
                )
                .GroupBy(rsv => rsv.EquipmentId)
                .Select(rsv => new EquipmentReservationsCountForMonthDTO
                {
                    equipmentId = rsv.Key,
                    name = rsv.First().Equipment.Name,
                    model = rsv.First().Equipment.Model,
                    count = rsv.Count(),
                    labId = rsv.First().Equipment.LabId,
                    labName = rsv.First().Equipment.Lab.LabName,
                })
                .ToList();
        }

        public List<EquipmentReservationsCountByMonthDTO> GetReservationsCountByMonth(int equipmentId)
        {
            return _dbContext
                .itemReservations.Where(rsv =>
                    rsv.IsActive
                    && rsv.EquipmentId == equipmentId
                )
                .GroupBy(rsv => new { rsv.StartDate.Year, rsv.StartDate.Month })
                .Select(rsv => new EquipmentReservationsCountByMonthDTO
                {
                    year = rsv.Key.Year,
                    month = rsv.Key.Month,
                    count = rsv.Count(),
                })
                .ToList();
        }
    }
}