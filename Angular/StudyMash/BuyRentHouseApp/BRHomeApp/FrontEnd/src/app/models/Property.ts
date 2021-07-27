import { IProperty } from "./IProperty.interface";
import { IPropertyBase } from "./IPropertyBase.interface";
export class Property implements IPropertyBase{
  Id!: number;
  Name!: string;
  Price!: number | null;
  SellRent!: number;
  PType!: string;
  FType!: string;
  BuiltArea!: number | null;
  CarpetArea? : number;
  BHK!: number | null;
  City!: string;
  RTM!: number;
  Image?: string | undefined;
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
