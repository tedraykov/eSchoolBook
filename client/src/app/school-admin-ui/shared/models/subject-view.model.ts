import {MinimalSchoolUser} from "../../../shared/models/minimal-school-user.interface";

export interface SubjectViewModel {
    id: string;
    name: string;
    grade: string;
    teachers: Array<MinimalSchoolUser>;
}
