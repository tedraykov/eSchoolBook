import {Roles} from "../../shared/enums/school-user-roles";
import {School} from "../../shared/models/school.interface";

export class SchoolUserInputModel {
    id: string;
    firstName: string;
    secondName: string;
    lastName: string;
    pin: string;
    address: string;
    town: string;
    schoolId: string;
    role: Roles;
}