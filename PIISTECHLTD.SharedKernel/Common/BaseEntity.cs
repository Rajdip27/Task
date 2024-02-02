﻿namespace PIISTECHLTD.SharedKernel.Common;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}
public abstract class BaseEntity : BaseEntity<long> { }
