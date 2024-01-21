# IPConnectionMapper
C# tool designed to perform network discovery and generate a JSON file containing information about machines that your local system can access. The tool utilizes the Nmap and Ncap tools for scanning and capturing network information.

# Features
1. Network Discovery: The tool uses Nmap to scan the local network and discover machines that are reachable from your system.
2. Information Gathering: It collects essential information about each discovered machine, such as IP addresses, open ports, and service details.
3. JSON Output: The tool organizes the gathered information into a structured JSON file, making it easy to parse and analyze the network details.

# Use Case
This tool is particularly useful for network administrators, security professionals, or anyone interested in understanding the devices connected to their local network. It provides a quick and automated way to discover and catalog machines, aiding in network monitoring and security assessments.

# Dependencies
Nmap: A powerful open-source network scanning tool that is used for host discovery, service enumeration, and vulnerability detection.
Ncap: A companion tool for Nmap that captures and saves network traffic during a scan.

# Note
Make sure to install Nmap and Ncap before running the tool, as they are essential dependencies for the proper functioning of your project.
