namespace ERP.Application.Accounting.Journals.GetJournalById;

public sealed record JournalDetailsDto(
    string Id,
    string Number,
    DateOnly AccountingDate,
    string? Reference,
    string Status,
    DateTimeOffset? PostedAt,
    IReadOnlyList<JournalLineDto> Lines
);

public sealed record JournalLineDto(
    string AccountId,
    decimal Debit,
    decimal Credit,
    string Currency,
    string? Description,
    string? ProjectId
);
