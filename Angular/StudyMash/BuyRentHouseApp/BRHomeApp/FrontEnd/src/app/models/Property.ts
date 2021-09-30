import { IProperty } from "./IProperty.interface";
import { IPropertyBase } from "./IPropertyBase.interface";
export class Property implements IPropertyBase{
  id!: number;
  name!: string;
  price!: number | null;
  sellRent!: number;
  propertyType!: string;
  furnishingType!: string;
  builtArea!: number | null;
  CarpetArea? : number;
  bhk!: number | null;
  city!: string;
  readyToMove!: number;
  image?: string | undefined;
  Address! : string;
  Address2! : string;
  FloorNo?: string;
  TotalFloor? : string;
  AOP?: string;
  Possession? : string;
  MainEntrance?:string;
  Security? : number;
  Gated?: number;
  Maintenance? : number;
  Description? : string;
  PostedOn! : string;
  PostedBy! : string;
}
