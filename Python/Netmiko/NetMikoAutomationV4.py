from netmiko import (
    ConnectHandler,
    NetmikoTimeoutException,
    NetmikoAuthenticationException,
)
import xlrd

def send_show_command(device, commands):
    result = {}
    try:
        with ConnectHandler(**device) as ssh:
            ssh.enable()
            for command in commands:
                #ssh.send_command(r'terminal length 0',expect_string=r'#|S|-|^')
                output = ssh.send_command(r''+command,expect_string=r'#|$|-|^')
                result[command] = output
        return result
    except (NetmikoTimeoutException, NetmikoAuthenticationException) as error:
        print(error)

def start_send_config_set(device, commands):
    result = {}
    try:
        with ConnectHandler(**device) as ssh:
            ssh.enable()
            for command in commands:
                ssh.send_command('terminal length 0')
                output = ssh.send_config_set(command)
                result[command] = output
        return result
    except (NetmikoTimeoutException, NetmikoAuthenticationException) as error:
        print(error)

def startTheAutomation(ExcelFilePath, CommandFilePath,ErrorFilePath, CommandType):
    filecommands:list = []
    with open(CommandFilePath) as file:
        for line in file:
            line = line.strip() #or some other preprocessing
            filecommands.append(line) #storing everything in memory!
    loc= (ExcelFilePath)

    wb = xlrd.open_workbook(loc)
    sheet = wb.sheet_by_index(0)
    for i in range(sheet.nrows):
        if i ==  0:
            continue
        else:
            row = sheet.row_slice(i)
            if row[0].value == "":
                break
            else:
                try:
                    cisco_881 = {
                        'device_type': row[0].value,
                        'ip':   row[1].value,
                        'username': row[2].value,
                        'password': row[3].value,
                        # Multiple all of the delays by a factor of two
                        "global_delay_factor": 4,
                        "fast_cli": False, 
                        'verbose': True,
                        'session_log': f'{row[1].value}.log'
                    }                    
                    result = {}
                    if CommandType == '1':
                        print("Processing Device :- "+row[1].value)
                        result = send_show_command(device=cisco_881,commands=filecommands)
                    else :
                        print("Processing Device :- "+row[1].value)
                        result = start_send_config_set(device=cisco_881,commands=filecommands)
                    output = ""
                    if result == None :
                        output = "No Data"
                    else :
                        for r in result:
                            output += r + " :"
                            output += result[r] + "\n\n"
                        fileName =ErrorFilePath +"\\"+ row[1].value+".txt"
                        f = open(fileName, "w+")
                        f.write(output)
                        f.close()
                except Exception as inst:
                    print(type(inst))    # the exception instance
                    print(inst.args)     # arguments stored in .args
                    print(inst)          # __str__ allows args to be printed directly,
                                        # but may be overridden in exception subclasses
                    continue

def startTheWork():
    print("Python Automation for Set Series of Show Command and Set Configuration to Internal System")
    ExcelFilePath = input("Enter your Excel File Path(only xls file): ")
    CommandFilePath = input("Enter your Command File Path(only txt file): ")
    ErrorFilePath = input("Enter your Error Folder Path: ")
    print("Check the below two option and select the appropriate")
    print("Press 1 for Show Command")
    print("Press 2 for Set Configuration Command")
    CommandType = input("")
    startTheAutomation(ExcelFilePath = ExcelFilePath, CommandFilePath = CommandFilePath, 
                       CommandType = CommandType, ErrorFilePath = ErrorFilePath)

startTheWork()