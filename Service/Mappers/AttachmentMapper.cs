using Data.Entities;
using Riok.Mapperly.Abstractions;
using Service.Services.Attachments;

namespace Service.Mappers;

[Mapper]
public partial class AttachmentMapper
{
    public partial AttachmentDto AttachmentToAttachmentDto(Attachment attachment);
    public partial Attachment AttachmentDtoToAttachment(AttachmentDto attachmentDto);
}