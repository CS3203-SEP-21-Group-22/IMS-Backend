﻿using FluentValidation;
using IMS.Application.DTO;
using IMS.Infrastructure.Services;
using IMS.Presentation.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Presentation.Controllers
{
    [Route("api/upload-url")]
    [ApiController]
    public class ImgUploadControllers : ControllerBase
    {
        private readonly IBlobStorageClient _blobStorageClient;
        private readonly ILogger<ImgUploadControllers> _logger;
        private readonly IValidator<PresignedUrlRequestDTO> _presignedUrlRequestValidator;

        public ImgUploadControllers(
            IBlobStorageClient blobStorageClient,
            ILogger<ImgUploadControllers> logger,
            IValidator<PresignedUrlRequestDTO> presignedUrlRequestValidator
        )
        {
            _blobStorageClient = blobStorageClient;
            _logger = logger;
            _presignedUrlRequestValidator = presignedUrlRequestValidator;
        }

        [HttpPost("lab")]
        [AuthorizationFilter(["SystemAdmin"])]
        public async Task<ActionResult<PresignedUrlResponseDTO>> GetPresignedURLForLab(
            PresignedUrlRequestDTO presignedUrlRequestDTO
        )
        {
            try
            {
                // Validate the DTO
                var result = await _presignedUrlRequestValidator.ValidateAsync(
                    presignedUrlRequestDTO
                );
                if (!result.IsValid)
                    return BadRequest(result.Errors);
                // Generate the presigned URL
                string blobName =
                    "labs/"
                    + presignedUrlRequestDTO.imageName
                    + "."
                    + presignedUrlRequestDTO.extension;
                TimeSpan expiryDuration = TimeSpan.FromMinutes(10);
                Uri presignedUrl = _blobStorageClient.GeneratePresignedUrl(
                    blobName,
                    expiryDuration
                );
                return Ok(new PresignedUrlResponseDTO(presignedUrl));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("equipment")]
        [AuthorizationFilter(["Clerk"])]
        public async Task<ActionResult<PresignedUrlResponseDTO>> GetPresignedURLForEquipment(
            PresignedUrlRequestDTO presignedUrlRequestDTO
        )
        {
            try
            {
                // Validate the DTO
                var result = await _presignedUrlRequestValidator.ValidateAsync(
                    presignedUrlRequestDTO
                );
                if (!result.IsValid)
                    return BadRequest(result.Errors);
                // Generate the presigned URL
                string blobName =
                    "equipments/"
                    + presignedUrlRequestDTO.imageName
                    + "."
                    + presignedUrlRequestDTO.extension;
                TimeSpan expiryDuration = TimeSpan.FromMinutes(10);
                Uri presignedUrl = _blobStorageClient.GeneratePresignedUrl(
                    blobName,
                    expiryDuration
                );
                return Ok(new PresignedUrlResponseDTO(presignedUrl));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
