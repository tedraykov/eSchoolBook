import {SchoolUserInputModel} from "../../models/school-user.model";

export class StudentInputModel extends SchoolUserInputModel {
    classId: string;
    startYear: number;
}