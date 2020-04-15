import {NbMenuItem} from "@nebular/theme";
import {Roles} from "../../../shared/enums/school-user-roles";
import DateTimeFormat = Intl.DateTimeFormat;

const superAdminMenu: NbMenuItem[] = [
    {
        title: 'Users', icon:"people-outline", expanded: true,
        children: [
            {title: 'Create School User', link: 'admin/user/create'}
        ],
    },
    {
        title: 'Schools', icon: 'home-outline', expanded: true,
        children: [
            {title: 'Add New School', link: 'admin/school/add'}
        ]
    }
];

const schoolAdminMenu: NbMenuItem[] = [
    {
        title: 'Dashboard', icon: "trending-up-outline", expanded: true,
        children: [
            {title: 'School Analytics', link: 'school-admin/statistics'}
        ]
    },
    {
        title: 'Users', icon: "people-outline", expanded: true,
        children: [
            {title: 'Add New', link: 'admin/user/create'}
        ],
    },
    {
        title: 'Subjects', icon: "book-outline", expanded: true,
        children: [
            {title: 'Active Subjects', link: 'school-admin/subjects'}
        ]
    },
    {
        title: 'Classes', icon: "award-outline", expanded: true,
        children: [
            {title: `${new Date().getFullYear()} Classes`, link: 'school-admin/classes'},
            {title: 'Add New', link: 'school-admin/classes/add'},
        ]
    },
    {
        title: 'School Archive', icon: "archive-outline", expanded: false,
        children: [
            {title: 'Teachers Data', link: 'principal/teachers'},
            {title: 'Students Data', link: 'principal/students'},
            {title: 'Parents Data', link: 'principal/parents'}
        ]
    }
];

const studentMenu: NbMenuItem[] = [
];

const teacherMenu: NbMenuItem[] = [
    {
        title: 'Subjects', icon: "book-outline", expanded: true,
        children: [
            {title: 'Curriculum', link: 'teacher/subject'}
        ]
    }
];

const principalMenu: NbMenuItem[] = [
    {
        title: 'Dashboard', icon: "trending-up-outline", expanded: true,
        children: [
            {title: 'School Analytics', link: 'principal/statistics'}
        ]
    },
    {
        title: 'School Archive', icon: "archive-outline", expanded: true,
        children: [
            {title: 'Teachers Data', link: 'principal/teachers'},
            {title: 'Students Data', link: 'principal/students'},
            {title: 'Parents Data', link: 'principal/parents'}
        ]
    }

];
const parentMenu: NbMenuItem[] = [
];

export const menuConfig: Map<string, NbMenuItem[]> = new Map([
    [Roles.SuperAdmin, superAdminMenu],
    [Roles.SchoolAdmin, schoolAdminMenu],
    [Roles.Student, studentMenu],
    [Roles.Teacher, teacherMenu],
    [Roles.Principal, principalMenu],
    [Roles.Parent, parentMenu]
]);
