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
  carpetArea? : number;
  bhk!: number | null;
  city!: string;
  readyToMove!: number;
  image?: string | undefined;
  address! : string;
  address2! : string;
  floorNo?: string;
  totalFloors? : string;
  aop?: string;
  estPossessionOn? : string;
  mainEntrance?:string;
  security? : boolean;
  gated?: boolean;
  maintenance? : number;
  description? : string;
  postedOn! : string;
  postedBy! : string;
}
